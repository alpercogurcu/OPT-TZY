<template>
  <div>
    <v-data-table
      :headers="headers"
      :items="desserts"
      item-key="sira_numarasi"
      sort-by="hesap_adi"
      class="elevation-1"
      group-by="hesap_adi"
      show-group-by
      show-select
      :single-select="true"
      v-model="selected"
      @click:row="rowClick"
    >
      <template v-slot:top>
        <v-btn @click="StokEkle">
          STOK EKLE
        </v-btn>
        <v-switch
          v-model="basSecBool"
          label="Üzerine Basınca Seç"
          class="pa-3"
        ></v-switch>
      </template>
    </v-data-table>

    <v-dialog v-model="dialog2" max-width="500px">
      <v-card>
        <v-card-title> Stok Adeti </v-card-title>
        <v-card-text>
          <div v-if="selected.length > 0">
           {{ selected[0].parcaAdi }} -- Kalan Üretim:
          {{ selected[0].KalanUretim }}
          </div>
          <div v-else>
            Lütfen bir seçimde bulunun.
          </div>
          <v-text-field
            v-model="eklenecekStokMiktari"
      
            type="number"
          >
          </v-text-field>
        </v-card-text>
        <v-card-actions>
             <div v-if="selected.length > 0">
          <v-btn color="primary" text @click="StokKayit">
            KAYDET
          </v-btn>
             </div>
          <v-btn color="primary" text @click="dialog2 = false">
            GERİ DÖN
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
//import axios from "axios";
//import router from '../router'
import { mapActions, mapState } from "vuex";

export default {
  data() {
    return {
      eklenecekStokMiktari: "",
      basSecBool: true,
      dialog2: false,
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
        {
          text: "Stok No",
          value: "stok_id",
          groupable: false,
        },

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
          text: "Sipariş Miktarı",
          value: "miktar",
          align: "right",
          groupable: false,
        },
        {
          text: "Stok Miktarı",
          value: "Stok_ToplamMiktar",
          align: "right",
          groupable: false,
        },
        {
          text: "Kalan Üretim",
          value: "KalanUretim",
          align: "right",
          groupable: false,
        },
        {
          text: "İrsaliye No",
          value: "irsaliye_id",
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
    ...mapActions(["UpdateSelectedItems"]),

    async getirKonumaGoreMalzemeListesi() {
      await this.$axios
        .get("/imalat/kalanuretim")
        .then((res) => {
          this.desserts = res.data;
          console.log(res.data);
        })
        .catch(() => {
          console.log("Hata.");
        });
    },

    rowClick(item, row) {
      if (this.basSecBool) {
        let selectState = row.isSelected ? false : true;

        row.select(selectState);
      }
    },

    StokEkle() {
      this.dialog2 = true;
      console.log("eklerim paşam");
    },

    async StokKayit() {
      let stokBilgileri = {
        stok_id: this.selected[0].stok_id,
        tedarikci: this.selected[0].tedarikci,
        miktar: this.eklenecekStokMiktari,
        irsaliye_detayID: this.selected[0].irsaliye_detayID,
        irsaliye_id: this.selected[0].irsaliye_id,
      };

      const gelenislem = await this.$axios
        .post("/isletme/stokekle", stokBilgileri)
        .then((res) => {
          return res;
        });

      if (gelenislem.statusText == "OK") {
        this.dialog2 = false;
        this.selected=[];
        this.getirKonumaGoreMalzemeListesi();
        
      }
  
    },

    SecilileriEsitle() {
      if (this.LastSelectedItemsPage == this.$route.name) {
        this.selected = this.selectedItems;
      }
    },
  },

  async created() {
    await this.getirKonumaGoreMalzemeListesi();
    this.SecilileriEsitle();
  },

  computed: {
    ...mapState(["selectedItems", "LastSelectedItemsPage"]),
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

<style></style>
