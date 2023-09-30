<template>
 <div class="mainContainer">
    <div class="accountContainer">
    <h1 class="pageTitle">Cart</h1>
    <div v-if="cartItems.length === 0">
      Your cart is empty.
    </div>
    <div v-else>
      <div v-for="(item, index) in cartItems" :key="index">
        <p>{{ item.name }} - ${{ item.price }} - Quantity: {{ item.quantity }}</p>
        <button @click="removeItem(index)">Remove</button>
      </div>
      <p>Total: ${{ total }}</p>
      <button @click="checkout">Checkout</button>
    </div>
  </div>
  </div>
</template>

<script>
export default {
  name: 'Cart',
  data() {
    return {
      cartItems: [] // Initialize cart items here
    };
  },
  computed: {
    total() {
      return this.cartItems.reduce((total, item) => total + item.price * item.quantity, 0);
    }
  },
  methods: {
    removeItem(index) {
      this.cartItems.splice(index, 1);
    },
    checkout() {
      // Implement checkout logic here
    }
  }
};
</script>


<style>
.mainContainer {
 display: flex;
  
  align-items: center;
  min-height: 100vh;
}

.accountContainer {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 75vw;
  max-width: 900px;
  margin-top: 50px;
  margin-bottom: 50px;
  padding: 20px;
  border-radius: 10px;
  box-shadow: 0px 15px 30px 20px rgba(0, 0, 0, 0.4);
  background-color: white;
  background-image: url('/public/img/headTransparent.png');
  background-repeat: repeat;
}

.pageTitle {
   margin-bottom: 20px;
  font-size: 50px;
  color: rgb(7, 128, 13);
   font-family: "TurtlesFont", sans-serif;
  text-shadow: 2.5px 1px #af0808;
  
}
</style>





