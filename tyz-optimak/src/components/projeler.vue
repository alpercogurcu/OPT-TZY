<template>
  <div>
    <v-card max-width="100%" class="mx-auto">
      <v-container>
        <v-row dense>
          <v-col v-for="(proje, i) in projeler" :key="i" cols="12">
            <v-card elevation="2">
              <v-card-title>
                {{ proje.uretim_kodu }} -
                {{ proje.takimSayisi }} TAKIM</v-card-title
              >
              <v-card-subtitle
                >Hat Kodu: {{ proje.hat_kodu }} |
                {{ proje.hesap_adi }}</v-card-subtitle
              >
              <v-card-actions>
                <v-btn
                  class="ml-2 mt-5"
                  outlined
                  rounded
                  small
                  @click.native="irsaliyeListesiniAc(proje.sd_id)"
                >
                  PROJE İRSALİYELERİNİ GÖRÜNTÜLE
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-card>
  </div>
</template>

<script>
//import { mapActions } from 'vuex';
import router from "../router";
export default {
  data: () => ({
    projeler: [],
  }),

  methods: {
    async getirsaliyeListesi() {
      await this.$axios
        .get("/projeler", null, {
          headers: { Authorization: `Bearer ${this.$store.state.token}` },
        })
        .then((res) => {
          if (res != null) this.projeler = res.data;
        });
      //   .catch((err) => console.log(err + " hata"));
    },
    irsaliyeListesiniAc(proje_id) {
      router.push({ path: "/irsaliyeler/" + proje_id });
    },
  },

  created() {
    this.getirsaliyeListesi();
  },

  mounted() {
    //this.getirsaliyeListesi();
  },

  computed: {
    //   this.getirsaliyeListesi();
  },
};
</script>
