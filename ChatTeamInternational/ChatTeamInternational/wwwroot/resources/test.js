import Vue from 'vue';
import Axios from 'axios';
import BaseLayout from './components/layout/BaseLayout.vue';

window.axios = Axios;

Vue.component("base-layout", BaseLayout);
new Vue({
    el: "#App"
});