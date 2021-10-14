<template>
  <v-navigation-drawer permanent>
    <v-list-item>
      <v-list-item-content>
        <v-list-item-title class="text-h6"> Hesap Bilgileri </v-list-item-title>
        <v-list-item-subtitle>
          Sadece çıkış yapabilirsiniz
        </v-list-item-subtitle>
      </v-list-item-content>
    </v-list-item>

    <v-divider></v-divider>

    <v-list dense nav>
      <v-list-item @click="logOut">
        <v-list-item-icon>
          <v-icon>mdi-logout</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>Çıkış Yap</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
import router from "../router";
import { mapActions } from "vuex";
export default {
  name: "hesapBilgileri",

  methods: {
    ...mapActions(["UpdateUserSettings", "UpdateSelectedItems"]),
    logOut() {
      let payload = {
        token: "",
        adsoyad: "",
      };

      this.UpdateUserSettings(payload);

      let payload2 = {
        selected: [],
        page: "",
      };

      this.UpdateSelectedItems(payload2);

      router.push("/login");
    },
  },
};
</script>

<style></style>
