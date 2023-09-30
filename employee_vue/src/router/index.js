import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import Orders from '../views/OrdersView.vue' 
import store from '../store/index'
import AuthService from '../services/AuthService'; 
import Menu from '../views/EditMenu.vue'
import OrderDetailsView from '../views/OrderDetailsView.vue';

Vue.use(Router)

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/employee',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/Employeelogin",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/Employeeregistration",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/orders', 
      name: 'orders',
      component: Orders,
      meta: {
        requiresAuth: true // This route requires authentication
      }
    },
    {
      path: '/editmenu', 
      name: 'editMenu',
      component: Menu,
      meta: {
        requiresAuth: true // This route requires authentication
      }
    },
    { path: '/order/:orderId', 
    name: 'order-details', 
    component: OrderDetailsView, 
    props: true }

  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '' && !AuthService.isLoggedIn()) {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;