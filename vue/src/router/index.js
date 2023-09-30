import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import OrderOnline from '../views/OrderOnline.vue';
import Menu from '../views/Menu.vue';
import Contact from '../views/ContactUs.vue';
import Cart from '../views/Cart.vue';
import Account from '../views/Account.vue';
import Checkout from '../views/Checkout.vue'

import Specialties from '../views/Specialties.vue'
import Custom from '../views/CustomPizza.vue'
import Wings from '../views/Wings.vue';
import Sides from '../views/Sides.vue';
import Drinks from '../views/Drinks.vue'


Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
    path: "/checkout",
    name: "checkout",
    component: Checkout,
    meta: {
      requiresAuth: false
    }
    },
    {
      path: "/specialties",
      name: "specialties",
      component: Specialties,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/custom",
      name: "custom",
      component: Custom,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
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
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/order',
      name: 'order',
      component: OrderOnline,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/menu',
      name: 'menu',
      component: Menu,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/contact',
      name: 'contact',
      component: Contact,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/cart',
      name: 'cart',
      component: Cart,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/account',
      name: 'account',
      component: Account,
      meta: { requiresAuth: false }
    },
    {
      path: '/',
      components: {
        default: Home,
        
      },
      meta: {
        requiresAuth: false
      }
    }, 
   
    {
      path: '/wings',
      component: Wings,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/sides',
      component: Sides,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/drinks',
      component: Drinks,
      meta: {
        requiresAuth: false
      }
    },
    {
    path: '/custom',
    component: Custom,
    meta: {
      requiresAuth: false
    }
  }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
