import { createApp } from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import { loadFonts } from './plugins/webfontloader'
import VentasView from './/components/Ventas/VentasView';
import { createRouter, createWebHistory } from 'vue-router';
import axios from 'axios';
import TableGeneric from './modules/TableGeneric.vue';
import DialogForm from './modules/DialogForm.vue';
import DialogFiles from './modules/DialogFiles.vue';
loadFonts()
const routes = [
  { path: '/ventas', component: VentasView, meta: { windowRedirectAfter: true } },
]
const router = createRouter({
  mode: history,
  base: process.env.CONTEXT,
  history: createWebHistory(),
  routes: routes
})
axios.defaults.baseURL = process.env.VUE_APP_BASE_URL;

const app = createApp(App)
app.use(vuetify)
app.use(router)
app.use(axiosApp)
app.component("table-generic", TableGeneric)
app.component("dialog-form", DialogForm)
app.component("dialog-files", DialogFiles)

app.mount('#app')



