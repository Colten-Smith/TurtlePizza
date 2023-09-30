<template>
  <div>
    <ul>
      <li v-for="order in recentOrders" :key="order.OrderID">
        <router-link :to="{ name: 'order-details', params: { orderId: order.OrderID } }">
          Order ID: {{ order.OrderID }}
        </router-link>
      </li>
    </ul>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      orders: []
    };
  },
  created() {
    this.fetchOrders(); 
  },
  methods: {
    fetchOrders() {
      axios.get('/Order')
        .then(response => {
          this.orders = response.data; 
        })
        .catch(error => {
          console.error('Error fetching orders:', error);
        });
    }
  }
};
</script>