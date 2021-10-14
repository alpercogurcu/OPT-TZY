<template>
  <div>
    <div v-if="!irsaliyeler.length">
      <v-alert prominent type="error">
        <v-row align="center">
          <v-col class="grow">
            Projeye atanmış herhangi bir irsaliye bulunamadı.
          </v-col>
          <v-col class="shrink">
            <v-btn @click="$router.go(-1)">Geri Dön</v-btn>
          </v-col>
        </v-row>
      </v-alert>
    </div>

    <div v-else>
      <v-card max-width="100%" class="mx-auto">
        <v-container>
          <v-row dense>
            <v-col v-for="(irsaliye, i) in irsaliyeler" :key="i" cols="12">
              <v-card elevation="2">
                <v-card-title> {{ irsaliye.irsaliye_no }}</v-card-title>
                <v-card-subtitle>
                  {{ irsaliye.tedarikci_adi }} --> {{ irsaliye.hedef_yeri }}
                </v-card-subtitle>
                <v-card-actions>
                  <v-btn
                    class="ml-2 mt-5"
                    outlined
                    rounded
                    small
                    @click.native="irsaliyeDetay(irsaliye.irsaliye_no)"
                  >
                    İRSALİYE DETAYINI GÖRÜNTÜLE
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-col>
          </v-row>
        </v-container>
      </v-card>
    </div>
  </div>
</template>

<script>
import router from "../router";
import { mapState } from "vuex";
export default {
  data: () => ({
    irsaliyeler: [],
  }),

  methods: {
    getirsaliyeListesi() {
      this.$axios
        .get("irsaliyeler/" + this.$route.params.id)
        .then((res) => {
          this.irsaliyeler = res.data;
          console.log(res.data);
        })
        .catch((err) => console.log(err));
    },

    irsaliyeDetay(irsNo) {
      router.push("/irsaliye/" + irsNo);
    },
  },

  created() {
    this.getirsaliyeListesi();
  },

  computed: {
    ...mapState(["token", "selectedItems"]),
  },
};
</script>
