<template>
  <v-main>
    <v-container fluid fill-height>
      <v-layout align-center justify-center>
        <v-flex xs12 sm8 md4
          ><v-alert text type="error" :value="alertShow"
            >Hatalı Kullanıcı adı veya Parola
          </v-alert>
          <v-card class="elevation-12">
            <v-toolbar dark color="primary">
              <v-toolbar-title>Kullanıcı Girişi</v-toolbar-title>
            </v-toolbar>
            <v-card-text>
              <v-form>
                <v-text-field
                  prepend-icon="mdi-account"
                  name="kullaniciadi"
                  label="Kullanıcı Adı"
                  v-model="kullaniciadi"
                  type="text"
                  @keydown.enter="kullaniciadienterabasti"
                ></v-text-field>
                <v-text-field
                  id="password"
                  prepend-icon="mdi-lock-outline"
                  ref="parola"
                  name="parola"
                  label="Parola"
                  v-model="parola"
                  type="password"
                  @keydown.enter="girisyap"
                ></v-text-field>
              </v-form>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="primary" @click="girisyap">GİRİŞ YAP</v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </v-main>
</template>

<script>
import { mapActions } from "vuex";
import router from "../router";
//import router from '../router'
export default {
  name: "login",
  data() {
    return {
      kullaniciadi: "",
      parola: "",
      alertShow: false,
    };
  },
  methods: {
    kullaniciadienterabasti() {
      this.$refs.parola.$refs.input.focus();
    },

    ...mapActions(["UpdateUserSettings"]),

    parseJwt(token) {
      var base64Url = token.split(".")[1];
      var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
      var jsonPayload = decodeURIComponent(
        atob(base64)
          .split("")
          .map(function(c) {
            return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
          })
          .join("")
      );

      return JSON.parse(jsonPayload);
    },

    async girisyap() {
      let kadi = JSON.stringify(this.kullaniciadi);
      let pass = JSON.stringify(this.parola);

      try {
        await this.$axios
          .post("/login", {
            kullaniciadi: JSON.parse(kadi),
            parola: JSON.parse(pass),
          })
          .then((res) => {
            if (res.data.status == -1) {
              this.alertShow = true;
            } else {
              const decode = this.parseJwt(res.data);

              let payload = {
                token: res.data,
                adsoyad: decode.adsoyad,
              };
       
            this.UpdateUserSettings(payload).then(() => {
              router.push("/"); 
            })
            
            ;
            }
          })

        
      } catch (err) {
        console.log("Hata?");
      }
    },
  },
  created() {
    // if(this.$store.state.token.length > 5 )
    //   router.go('/');
  },
};
</script>

<style></style>
