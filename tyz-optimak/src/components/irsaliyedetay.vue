<template>
  <div>
    <v-card class="mx-auto" max-width="100%">
      <v-toolbar color="indigo" dark>
        <v-toolbar-title>
          <v-icon>mdi-page-next</v-icon>
          {{ this.$route.params.id }}</v-toolbar-title
        >

        <v-spacer></v-spacer>
        {{ olusturmaTarihi }}
      </v-toolbar>

      <v-container fluid>
        <v-row dense>
          <v-col cols="12" sm="4">
            <v-card class="pa-2" outlined tile>
              <b>Tedarikçi: </b> {{ baslik.tedarikci_adi }}
            </v-card>
          </v-col>

          <v-col cols="12" sm="4">
            <v-card class="pa-2" outlined tile
              ><b>Hedef Yeri: </b> {{ baslik.hedef_yeri }}
            </v-card>
          </v-col>

          <v-col cols="12" sm="4">
            <v-card class="pa-2" outlined tile
              ><b>Termin Tarihi: </b> {{ terminTarihi }}
            </v-card>
          </v-col>

          <v-col cols="12" sm="12">
            <v-card class="pa-2" outlined tile
              ><b>Açıklama: </b> {{ baslik.aciklama }}
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-card>

    <v-data-table
      v-model="selected"
      :headers="headers"
      :items="desserts"
      :single-select="singleSelect"
      item-key="id"
      show-select
      class="elevation-1"
      @click:row="rowClick"
    >
      <template v-slot:top>
        <v-switch
          v-model="basSecBool"
          label="Üzerine Basınca Seç"
          class="pa-3"
        ></v-switch>
      </template>
    </v-data-table>
  </div>
</template>

<script>
//import axios from "axios";
import moment from "moment";
import { mapActions, mapState } from "vuex";

export default {
  data: () => ({
    basSecBool: true,
    baslik: [],
    olusturmaTarihi: "",
    terminTarihi: "",
    detay: [],
    selected: [],
    singleSelect: false,
    headers: [
      { text: "Parça Adı", value: "parcaAdi" },
      { text: "Miktar", value: "stokMiktari" },
      { text: "Uzunluk", value: "uzunluk" },

      { text: "Anlık Stok Miktari", value: "anlikStokMiktari" },

      { text: "Birim", value: "birim" },

      { text: "Birim Fiyat", value: "birimFiyat" },
      { text: "Termin Tarihi", value: "terminTarihi" },
      { text: "Üretim Kodu", value: "uretim_kodu" },
    ],
    desserts: [],
  }),

  methods: {
    ...mapActions(["UpdateSelectedItems"]),

    getirsaliyeDetay() {
      this.$axios
        .get("http://192.168.1.203:3000/irsaliye/" + this.$route.params.id)
        .then((res) => {
          this.baslik = res.data[0][0];
          this.olusturmaTarihi = moment(this.baslik.olusturmaTarihi).format(
            "DD-MM-YYYY"
          );
          this.terminTarihi = moment(this.baslik.terminTarihi).format(
            "DD-MM-YYYY"
          );

          this.desserts = res.data[1];
          //  this.irsaliyeler = res.data;
        })
        .catch((err) => console.log(err));
    },

    rowClick(item, row) {
      if (this.basSecBool) {
        let selectState = row.isSelected ? false : true;
        row.select(selectState);
      }
    },
  },

  computed: {
    ...mapState(["selectedItems", "LastSelectedItemsPage"]),
  },

  created() {
    this.getirsaliyeDetay();
  },

  mounted: function() {
    //  this.getirsaliyeDetay();
  },

  watch: {
    selected() {
      let payload = {
        selected: this.selected,
        page: this.$route.name,
      };
      console.log(payload);
      this.UpdateSelectedItems(payload);
    },
  },
};
</script>
