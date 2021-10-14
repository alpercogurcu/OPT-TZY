import Vue from 'vue'
import VueRouter from 'vue-router'

import Projeler from '../components/projeler'
import irsaliyeListesi from '../components/irsaliyeListesi'
import irsaliyedetay from '../components/irsaliyedetay'
import irsaliyeolustur from '../components/irsaliyeolustur'
import konumaGoreMalzemeListesi from '../components/konumaGoreMalzemeListesi'
import login from '../components/login'
import hesapBilgileri from '../components/hesapbilgileri'
import imalat from '../components/imalat'


Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'index',
    component: Projeler,
    meta: {
      reload: true,
    },
  },
  {
    path: '/irsaliyeler/:id',
    name: 'İrsaliyeler',
    component: irsaliyeListesi
  },

  {
    path: '/irsaliye/:id',
    name: 'irsaliyedetay',
    component: irsaliyedetay
  },
  {
    path: '/irsaliyeolustur',
    name: 'irsaliyeolustur',
    component: irsaliyeolustur
  },
  {
    path: '/malzemelistesi',
    name: 'malzemelistesi',
    component: konumaGoreMalzemeListesi
  },
  {
    path: '/login',
    name: 'login',
    component: login,
    meta: {
      reload: true,
    },
   
  },
  {
    path :'/hesapbilgileri',
    name: 'hesapBilgileri',
    component: hesapBilgileri
  },
  {
    path :'/imalat',
    name: 'imalEdilecekParcalar',
    component: imalat
  },

]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
