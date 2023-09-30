<template>
  <div>
    <h2>Recent Orders</h2>
    <OrdersList />
  </div>
</template>

<script>
import OrdersList from '../components/OrdersList.vue';

export default {
  components: {
    OrdersList
  }
};
</script>