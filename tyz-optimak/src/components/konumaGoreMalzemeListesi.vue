<template>
  <div>
    <v-data-table
      :headers="headers"
      :items="filteredDesserts"
      item-key="sira_numarasi"
      sort-by="hesap_adi"
      class="elevation-1"
      group-by="hesap_adi"
      show-group-by
      show-select
      v-model="selected"
      @toggle-select-all="selectAllToggle"
      @click:row="rowClick"
    >
      <template v-slot:top>
        <v-switch
          v-model="basSecBool"
          label="Üzerine Basınca Seç"
          class="pa-3"
        ></v-switch>
      </template>

      <template v-slot:[`item.stokMiktari`]="{ item }">
        <v-chip :color="getColor(item.stokMiktari)" dark>
          {{ item.stokMiktari }}
        </v-chip>
      </template>

      <template
        v-slot:[`item.data-table-select`]="{ item, isSelected, select }"
      >
        <v-simple-checkbox
          :value="isSelected"
          :readonly="item.stokMiktari < 0"
          :disabled="item.stokMiktari < 0"
          :ripple="false"
          @input="select($event)"
        ></v-simple-checkbox>
      </template>

      <template v-slot:header="{}">
        <tr class="grey lighten-3">
          <th>
            <v-icon>mdi-filter</v-icon>
          </th>
          <th v-for="header in headers" :key="header.text">
            <div v-if="filters.hasOwnProperty(header.value)">
              <v-autocomplete
                flat
                hide-details
                multiple
                attach
                chips
                dense
                clearable
                :items="columnValueList(header.value)"
                v-model="filters[header.value]"
              >
                <template v-slot:selection="{ item, index }">
                  <v-chip v-if="index < 5">
                    <span>
                      {{ item }}
                    </span>
                  </v-chip>
                  <span v-if="index === 5" class="grey--text caption">
                    (+{{ filters[header.value].length - 5 }} others)
                  </span>
                </template>
              </v-autocomplete>
            </div>
          </th>
        </tr>
      </template>
    </v-data-table>
  </div>
</template>

<script>
//import axios from "axios";
//import router from '../router'
import { mapActions, mapState } from "vuex";

export default {
  data() {
    return {
      basSecBool: true,

      isletmeadi: "",
      uretimkodu: "",

      filters: {
        hesap_adi: [],
        uretim_kodu: [],
      },

      malzemelistesi: [],
      headers: [
        {
          text: "Parça Adı",
          align: "start",
          value: "parcaAdi",
          groupable: false,
        },
        { text: "Uzunluk", 
        value: "uzunluk" },

        {
          text: "İşletme Adı",
          value: "hesap_adi",
          align: "center",
        },
        {
          text: "Üretim Kodu",
          value: "uretim_kodu",
          align: "center",
          groupable: true,
        },
        {
          text: "Stok Miktarı",
          value: "stokMiktari",
          align: "right",
          groupable: false,
        },
        {
          text: "Stok Birimi",
          value: "birim",
          align: "right",
          groupable: false,
        },
      ],
      desserts: [],
      selected: [],
      toggleIsSelectedBool: false,
    };
  },

  methods: {
    selectAllToggle(props) {
      if (this.toggleIsSelectedBool) {
        this.selected = [];
        this.toggleIsSelectedBool = false;
      } else {
        this.selected = [];
        const self = this;
        props.items.forEach((item) => {
          if (item.stokMiktari > 0) {
            self.selected.push(item);
          }
        });

        this.toggleIsSelectedBool = true;
      }

      if (this.selected.length == 0) this.toggleIsSelectedBool = false;
    },

    columnValueList(val) {
      return this.desserts.map((d) => d[val]);
    },
    getColor(stokMiktari) {
      if (stokMiktari < 0) return "red";
      else return "green";
    },

    ...mapActions(["UpdateSelectedItems"]),

    async getirKonumaGoreMalzemeListesi() {
      await this.$axios
        .get("/konumagoremalzemelistesi/")
        .then((res) => {
          this.desserts = res.data;
        })
        .catch(() => {
          console.log("Hata.");
        });
    },

    rowClick(item, row) {
      if (this.basSecBool) {
        let selectState = row.isSelected ? false : true;

        if (item.stokMiktari < 0) {
          row.select(false);
          return;
        }

        row.select(selectState);
      }
    },

    SecilileriEsitle() {
      if (this.LastSelectedItemsPage == this.$route.name) {
        this.selected = this.selectedItems;
      }
      /*
       this.desserts.map(item => {
      if (item.stokMiktari < 0)
      {
      this.disabledCount += 1
      }
    }) */
    },
  },
  async created() {
    await this.getirKonumaGoreMalzemeListesi();
    this.SecilileriEsitle();
  },

  computed: {
    ...mapState(["selectedItems", "LastSelectedItemsPage"]),

    filteredDesserts() {
      return this.desserts.filter((d) => {
        return Object.keys(this.filters).every((f) => {
          return this.filters[f].length < 1 || this.filters[f].includes(d[f]);
        });
      });
    },
  },
  watch: {
    selected() {
      let payload = {
        selected: this.selected,
        page: this.$route.name,
      };

      this.UpdateSelectedItems(payload);
    },
  },
};
</script>

<style>
.style-BGKirmizi {
  background-color: red;
}
</style>
