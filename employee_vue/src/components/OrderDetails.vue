<template>
  <div>
    <h3>Order ID: {{ order.OrderID }}</h3>
    <p>Total Price: ${{ order.TotalPrice }}</p>
    <p>Is Delivery: {{ order.IsDelivery ? 'Yes' : 'No' }}</p>
    <p>Order Status: {{ getOrderStatus(order.OrderStatus) }}</p>
    <p>Start Time: {{ order.StartTime || 'Not started' }}</p>
    <p>Delivery Time: {{ order.DeliveryTime || 'Not delivered' }}</p>
    <p>Complete Time: {{ order.CompleteTime || 'Not completed' }}</p>
    <p>Notes: {{ order.Notes || 'No notes' }}</p>
    
  </div>
</template>

<script>
import axios from 'axios';

export default {
  props: {
    orderId: {
      type: Number,
      required: true
    }
  },
  data() {
    return {
      order: null
    };
  },
  created() {
    this.fetchOrderDetails();
  },
  methods: {
    async fetchOrderDetails() {
      try {
        const response = await axios.get(`/order/${this.orderId}`);
        this.order = response.data;
      } catch (error) {
        console.error('Error fetching order details:', error);
      }
    },
    getOrderStatus(status) {
      
      switch (status) {
        case 1:
          return 'Placed';
        case 2:
          return 'Preparing';
        case 3:
          return 'Boxing';
        case 4:
          return 'Delivering';
        case 5:
          return 'Complete';
        default:
          return 'Unknown';
      }
    }
  }
};
</script>