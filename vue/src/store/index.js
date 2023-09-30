import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
/* this is for if we have already logged in */
let currentToken = localStorage.getItem('token')
let currentUser = '';
try{
  currentUser = JSON.parse(localStorage.getItem('user'));
} catch(e) {
  currentToken = '';
  localStorage.removeItem('token');
  localStorage.removeItem('user');
}


if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    newKey: 1,
    token: currentToken || '',
    user: currentUser || {},
    pizzas: [],
    wings: [],
    sides: [],
    drinks: [],
    sizes: [{sizeID: 1, sizeName: 'Small'}, {sizeID: 2, sizeName: 'Medium'}, {sizeID: 3, sizeName: 'Large'}],
    selectedPizzas: [],
    selectedSides: [],
    selectedDrinks: [],
    address: {},
    payment: {},
    order: {
      userID: 0,
      name: '',
      isDelivery: true,
      orderStatus: 0,
      notes: "",
      paymentID: 0,
      addressID: 0,
      pizzaIDs: [],
      sides: [],
      drinks: []
    },
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      /* for when we log in through the front end. Saving the data */
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      /* for when we log in through the front end. Saving the data */
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    GETPIZZAS(state, pizzas){
      state.pizzas = pizzas
    },
    GETWINGS(state, wings){
      state.wings = wings
    },
    GETSIDES(state, sides){
      state.sides = sides
    },
    GETDRINKS(state, drinks){
      state.drinks = drinks
    },
    GETSIZES(state, sizes){
      state.sizes = sizes
    },
    ADDPIZZATOORDER(state, data){
      state.order.pizzaIDs.push(data.outputPizza);
      data.newPizza.itemKey = state.newKey
      state.newKey += 1
      state.selectedPizzas.push(data.newPizza);
    },
    ADDSIDETOORDER(state, side){
      state.order.sides.push(side.id);
      side.itemKey = state.newKey
      state.newKey += 1
      state.selectedSides.push(side);
    },
    ADDDRINKTOORDER(state, drink){
      state.order.drinks.push(drink.id);
      drink.itemKey = state.newKey
      state.newKey += 1
      state.selectedDrinks.push(drink);
    },
    UPDATEADDRESS(state, newAddress){
      state.address = newAddress
    },
    UPDATEPAYMENT(state, newPayment){
      state.payment = newPayment
    },
    UPDATEORDERINFO(state, newInfo){
      state.order.name = newInfo.name
      state.order.notes = newInfo.notes
    },
    UPDATEORDERADDRESS(state, newAddress){
      state.order.addressID = newAddress
    },
    UPDATEORDERPAYMENT(state, newPayment){
      state.order.paymentID = newPayment
    }
  }
})
