<template>
  <div>
    <h2>Order Details - Order ID: {{ orderId }}</h2>
    <OrderDetails :orderId="orderId" />
  </div>
</template>

<script>
import OrderDetails from '@/components/OrderDetails.vue';

export default {
  components: {
    OrderDetails
  },
  props: {
    orderId: {
      type: Number,
      required: true
    }
  }
};
</script>