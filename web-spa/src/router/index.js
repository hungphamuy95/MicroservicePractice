import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../components/Navigation.vue'
import Test from '../components/WelcomPage.vue'

Vue.use(VueRouter)

  const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/test',
    name: 'Test',
    component: Test
  }
]

const router = new VueRouter({
  base: process.env.BASE_URL,
  routes
})

export default router
