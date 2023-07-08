import { createRouter, createWebHistory } from 'vue-router'

export enum routeNames {
  Home = "home",
  Payments = "payments"
}

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: routeNames.Home,
      component: () => import('@/views/HomeView.vue')
    },
    {
      path: '/payments',
      name: routeNames.Payments,
      component: () => import('@/views/UserPayments.vue')
    },
  ]
})

export default router
