<template>
  <v-app>
    <v-system-bar height="23"></v-system-bar>
    <v-app-bar app color="primary" dark>
      

      <div class="d-flex align-center">
        <a href='/hesapbilgileri'>
        <v-img
          alt="Vuetify Logo"
          class="shrink mr-2"
          contain
          src="https://optimak.com.tr/wp-content/uploads/2020/09/optimakkonveyorstrec-sarmahat-sonu-1.png"
          transition="scale-transition"
          width="60"
   
        /></a>
      TZY Paneli
     
        <!-- <v-img
          alt="Vuetify Name"
          class="shrink mt-1 hidden-sm-and-down"
          contain
          min-width="100"
          src="https://cdn.vuetifyjs.com/images/logos/vuetify-name-dark.png"
          width="100"
        /> -->
      </div>
      
      <v-spacer></v-spacer>

      <v-btn @click="IrsaliyeOlusturBtn" text>
        <span class="mr-2">{{  GetYeniIrsaliyeBaslik }}</span>
        <v-icon>mdi-open-in-new</v-icon>
      </v-btn>
    </v-app-bar>

    <v-main>
      <router-view />
    </v-main>

    <bottom-bar> </bottom-bar>
  </v-app>
</template>

<script>
import BottomBar from "./components/bottom.vue";
import router from "./router";
import { mapState, mapGetters, mapActions } from "vuex";

export default {
  name: "App",

  components: {
    BottomBar,
  },

  data: () => ({}),

  methods: {
    ...mapActions(["UpdateUserSettings","UpdateSelectedItems"]),
    IrsaliyeOlusturBtn() {
      if (this.selectedItems.length > 0) {
        router.push("/irsaliyeolustur");
      } else {
        router.push("/malzemelistesi");
      }
    },

  
  },

  computed: {
    ...mapState(["token", "selectedItems"]),

    ...mapGetters(["GetYeniIrsaliyeBaslik"]),
  },
};
</script>
