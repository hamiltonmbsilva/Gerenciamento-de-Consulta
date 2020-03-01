import Vue from 'vue';
import App from './App.vue';
import BootstrapVue from "bootstrap-vue";
import VueRouter from "vue-router";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import VueMask from 'v-mask';

Vue.use(VueRouter);
Vue.use(BootstrapVue);
Vue.use(VueMask);


Vue.config.productionTip = false

import Agendamento from "./pages/agendamento.vue";
import AgendamentoForm from "./pages/agendamentoForm.vue";

import Paciente from "./pages/paciente.vue";
import PacienteForm from "./pages/pacienteForm.vue";
import PacienteAlterarFrom from "./pages/pacienteAlterarFrom.vue";


const routes = [
  { path: "/", component: Agendamento },
  { path: "/agendamentos", component: Agendamento },
  { path: "/agendamentos/cadastrar", component: AgendamentoForm },
  { path: "/paciente", component: Paciente },
  { path: "/paciente/cadastrar", component: PacienteForm },
  { path: "/paciente/alterar", component: PacienteAlterarFrom }
];

const router = new VueRouter({
  routes,
  mode: "history" //remove o # da url
});

new Vue({
  router,
  el: "#app",
  render: h => h(App)
}).$mount('#app');
