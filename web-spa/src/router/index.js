import Vue from 'vue'
import VueRouter from 'vue-router'
import Board from '../components/Navigation.vue'
import Home from '../components/WelcomPage.vue'
import guard from './../common/guard'
import Callback from '../components/WaitingLogin.vue'

Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/callback',
    name: 'Callback',
    component: Callback
  },
  {
    path: '/board',
    name: 'Board',
    component: Board,
    beforeEnter: (to, fr, next) => {
      guard(to, fr, next)
    }
  }
]

const router = new VueRouter({
  base: process.env.BASE_URL,
  routes
})

export default router
