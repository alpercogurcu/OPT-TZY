import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'


import VueRouter from 'vue-router'
import Vuex from 'vuex'
import router from './router'
import store from './store'
import axios from "axios";


Vue.config.productionTip = false
Vue.use(VueRouter)
Vue.use(Vuex)




const axiosInstance = axios.create({
  baseURL: "http://85.105.100.117:3000/",
});

axiosInstance.interceptors.request.use(config => {



        config.headers = Object.assign({
            Authorization: `Bearer ${store.state.token}`
        }, config.headers);
    
    return config;
},
error => {
    return Promise.reject(error);
}
);

axiosInstance.interceptors.response.use(null, function(error){

  if(error.response.status == 401){
 
    router.push('/login');
  }
  else if (error.response.status == 403)
{
  return error.response
}

  
});

Vue.prototype.$axios = axiosInstance;

Vue.config.productionTip = false;



new Vue({
  vuetify,
  router,
  store,
  render: h => h(App)
}).$mount('#app')
