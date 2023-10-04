import { createRouter, createWebHistory } from 'vue-router'
import BattleShip from '@/views/BattleShip/Index.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/battleship',
      name: 'battleship',
      component: BattleShip
    }
  ]
})

export default router
