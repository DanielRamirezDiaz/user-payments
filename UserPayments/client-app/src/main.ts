import { createApp } from 'vue'
import { createPinia } from 'pinia'
import AxiosInterceptors from "@/utilities/interceptors"

import App from './App.vue'
import router from './router'

import './assets/main.css'
import axios from 'axios'

const app = createApp(App)

app.use(createPinia())
app.use(router)

AxiosInterceptors.ConfigureInterceptors(router);

app.mount('#app')
