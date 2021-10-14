import Vue from "vue";
import Vuex from "vuex";
import createPersistedState from "vuex-persistedstate";
//import router from '../router'


Vue.use(Vuex);

const state = {
    token: '',
    adsoyad:'',
    selectedItems: [],
    LastSelectedItemsPage: '',
};
const getters = {

    GetYeniIrsaliyeBaslik(state){
 //       console.log(router.history.current);
        if(state.selectedItems.length > 0)
        return `YENİ İRSALİYE (${state.selectedItems.length})`
        else
        return 'MALZEME LİSTESİ'
    }

};

const mutations = {

    SetUserName(state, token) {
        state.token = token;
    },

    SetSelectedItems(state, payload ) {
        state.selectedItems = payload.selected;
        state.LastSelectedItemsPage = payload.page;
    },

    SetUserSettings(state, payload)
    {
        state.token = payload.token;
        state.adsoyad = payload.adsoyad;
    },

    TruncateSelectedItems(state)
    {
        state.selectedItems = [],
        state.LastSelectedItemsPage = ''
    }



};

const actions = {

    UpdateUserName({ commit }, token) {
        commit('SetUserName', token);
    },

    UpdateSelectedItems({ commit }, payload ) {
        
        commit('SetSelectedItems', payload);
    },

    UpdateUserSettings({commit}, payload)
    {
        commit('SetUserSettings', payload);
    },

    ClearSelectedItems({commit})
    {
        commit('TruncateSelectedItems');
    }

};

const store = new Vuex.Store({
    state,
    getters,
    mutations,
    actions,
    plugins: [createPersistedState()],
});


export default store;