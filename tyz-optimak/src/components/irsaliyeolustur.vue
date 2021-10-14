<template>
  <div>
    <v-stepper v-model="e1">
      <v-stepper-header>
        <v-stepper-step :complete="e1 > 1" step="1">
          İrsaliye İçeriğini Onayla
        </v-stepper-step>

        <v-divider> </v-divider>

        <v-stepper-step :complete="e1 > 2" step="2">
          İrsaliyeyi Kaydet
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="3">
          İrsaliye Bilgilerini Görüntüle
        </v-stepper-step>
      </v-stepper-header>

      <v-stepper-items>
        <v-stepper-content step="1">
          <v-card class="mb-12" color="white lighten-1">
            <!--- STEP 1 içerik --->
            <v-data-table
              :headers="headers"
              :items="desserts"
              class="elevation-1"
            >
              <template v-slot:[`item.transferMiktari`]="props">
                <v-text-field
                  v-model="props.item.transferMiktari"
                  :suffix="props.item.birim"
                  type="number"
                >
                </v-text-field>
              </template>
            </v-data-table>
            <!---- STEP 1 İÇERİK SONU --->
          </v-card>
          <v-btn
            color="primary"
            @click="
              e1 = 2;
              dialog3 = true;
            "
          >
            ONAYLA
          </v-btn>
          <v-btn text @click="DialogGeriDon"> GERİ DÖN </v-btn>
        </v-stepper-content>

        <v-stepper-content step="2">
          <v-card class="mb-12" color="white lighten-1">
            <v-container fluid>
              <v-row dense>
                <v-col cols="12" sm="4">
                  <v-card class="pa-2" outlined tile>
                    <b>Tedarikçi: </b> {{ desserts[0].hesap_adi }}
                  </v-card>
                </v-col>

                <v-col cols="12" sm="4">
                  <v-card class="pa-2" outlined tile
                    ><b>Hedef Yeri: </b>
                    <template v-if="hedefyeriDepoCheckbox">
                      {{ HedefYeriSecilenKonum.depo_adi }}
                    </template>
                    <template v-else>
                      {{ HedefYeriSecilenKonum.hesap_adi }}
                    </template>
                    <v-btn elevation="2" fab x-small @click="dialog3 = true">
                      <v-icon dark>
                        mdi-wrench
                      </v-icon>
                    </v-btn>
                  </v-card>
                </v-col>

                <v-col cols="12" sm="4">
                  <v-card class="pa-2" outlined tile
                    ><b>Termin Tarihi: </b> {{ TerminTarihi }}
                  </v-card>
                </v-col>

                <v-col cols="12" sm="12">
                  <v-card class="pa-2" outlined tile
                    ><b>Açıklama: </b>
                  <v-textarea
          filled
          name="input-7-4"
          label="Filled textarea"
          value="The Woodman set to work at once, and so sharp was his axe that the tree was soon chopped nearly through."
        ></v-textarea>
                  </v-card>
                </v-col>
              </v-row>
            </v-container>
          </v-card>
          <v-btn
            color="primary"
            @click="irsaliyeKaydet"
            :disabled="irsaliyeAktarButonDisabled"
            >İRSALİYEYİ KAYDET</v-btn
          >
          <v-btn text @click="e1 = 1">GERİ DÖN</v-btn>
        </v-stepper-content>

        <v-stepper-content step="3">
          <v-card class="mb-12" color="white lighten-1">
            <br />
            İrsaliye No: {{ gelenIrsaliye.irsaliye_no }}
            <br />
          </v-card>

          <v-btn color="primary" @click="AnasayfayaDon"> BİTİR </v-btn>
        </v-stepper-content>
      </v-stepper-items>
    </v-stepper>

    <v-dialog v-model="dialog2" max-width="500px">
      <v-card>
        <v-card-title> İşletme Seçimi </v-card-title>
        <v-card-text>
          <v-select
            v-model="secilenIsletme"
            :items="selectedItems"
            label="İrsaliyeyi oluşturmak istediğiniz işletmeyi seçiniz."
            item-value="isletme_id"
            item-text="hesap_adi"
          >
          </v-select>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" text>
            <div v-if="secilenIsletme != ''" @click="DialogSecim">
              SEÇ
            </div>
            <div v-else>SEÇ</div>
          </v-btn>
          <v-btn color="primary" text @click="DialogGeriDon"> GERİ DÖN </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <v-dialog v-model="dialog3" max-width="500px">
      <v-card>
        <v-card-title> İşletme Seçimi </v-card-title>
        <v-card-text>
          <v-checkbox
            v-model="hedefyeriDepoCheckbox"
            label="Hedef Yeri Depo"
          ></v-checkbox>

          <v-select
            v-if="hedefyeriDepoCheckbox"
            v-model="HedefYeriSecilenKonum"
            :items="depolar"
            label="Transfer etmek istediğiniz depoyu seçiniz."
            item-value="id"
            item-text="depo_adi"
            return-object
          >
          </v-select>

          <v-select
            v-else
            v-model="HedefYeriSecilenKonum"
            :items="isletmeler"
            label="Transfer etmek istediğiniz işletmeyi seçiniz."
            item-value="id"
            item-text="hesap_adi"
            return-object
          ></v-select>
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" text>
            <div v-if="HedefYeriSecilenKonum != ''" @click="dialog3 = false">
              SEÇ
            </div>
            <div v-else>SEÇ</div>
          </v-btn>
          <v-btn color="primary" text @click="DialogGeriDon"> GERİ DÖN </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    {{ desserts }}
  </div>
</template>

<script>
import router from "../router";
import { mapState, mapActions } from "vuex";

export default {
  data() {
    return {
      e1: 1,
      secilenIsletme: "",
      dialog2: false,
      dialog3: false,
      hedefyeriDepoCheckbox: false,

      isletmeler: [],
      depolar: [],
      HedefYeriSecilenKonum: "",
      HedefYeriSecilenText: "",
      TerminTarihi: "",
      Aciklama: "",

      gelenIrsaliye: {
        irsaliye_no: "",
        id: "",
      },

      irsaliyeAktarButonDisabled: false,

      headers: [
        {
          text: "Parça Adı",
          align: "start",
          value: "parcaAdi",
        },
        {
          text: "İşletme Adı",
          value: "hesap_adi",
          align: "start",
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
          align: "center",
          groupable: false,
        },
        {
          text: "Transfer Miktarı",
          value: "transferMiktari",
          align: "center",
          groupable: false,
        },
      ],
      desserts: [],
    };
  },

  methods: {
    ...mapActions(["UpdateSelectedItems"]),
    AcilisKontrol() {
      var arr = [];
      const current = new Date();
      const date = `${current.getDate()}/${current.getMonth() +
        1}/${current.getFullYear()}  ${current.getHours()}:${current.getMinutes()}`;
      this.TerminTarihi = date;

      this.$axios
        .get("/depoveisletmebilgileri")
        .then((res) => {
          this.depolar = res.data[0];
          this.isletmeler = res.data[1];
        })
        .catch((err) => console.log(err));

      for (let j = 1; j < this.selectedItems.length; j++) {
        if (
          JSON.stringify(this.selectedItems[j - 1].isletme_id) !=
          JSON.stringify(this.selectedItems[j].isletme_id)
        ) {
          arr.push(this.selectedItems[j]);
        }
      }

      if (arr.length > 0) this.dialog2 = true;

      this.desserts = this.selectedItems;
      for (let i = 0; i < this.desserts.length; i++) {
        this.desserts[i].transferMiktari = this.desserts[i].stokMiktari;
      }
    },

    async irsaliyeKaydet() {
      this.irsaliyeAktarButonDisabled = true;

      let irsaliye = {
        items: this.desserts,
        tedarikci: this.desserts[0].isletme_id,
        hedef: this.HedefYeriSecilenKonum,
        hedefBirimDepo: this.hedefyeriDepoCheckbox,
        Aciklama: this.Aciklama,
        cikisBirimDepo: false,
        kullaniciadi: "alpercogurcu",
        irsaliye_kod_id: 6,
      };

      const gelenIrsaliyeRes = await this.$axios
        .post("/irsaliyeolustur", irsaliye)
        .then((res) => {
          return res;
        });

      this.gelenIrsaliye = {
        irsaliye_no: gelenIrsaliyeRes.data[0].irsaliye_no,
        id: gelenIrsaliyeRes.data[0].id,
      };

      let payload = {
        selected: [],
        page: "",
      };

      this.UpdateSelectedItems(payload);
      this.e1 = 3;
    },

    getSelectText(text) {
      this.HedefYeriSecilenText = text;
    },

    DialogSecim() {
      let arr = [];

      for (let i = 0; i < this.desserts.length; i++) {
        if (this.desserts[i].isletme_id == this.secilenIsletme) {
          arr.push(this.desserts[i]);
        }
      }

      this.desserts = [];
      this.desserts = arr;

      this.dialog2 = false;
    },

    DialogGeriDon() {
      router.go(-1);
    },

    AnasayfayaDon() {
      router.push("/");
    },
  },

  created() {
    this.AcilisKontrol();
  },
  computed: {
    ...mapState(["selectedItems"]),
  },
};
</script>

<style></style>
