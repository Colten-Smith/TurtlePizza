<template>
  <div class="specialtiesBody" >
    <food-button v-for="item in pizzas" :price="item.price" :key="item.pizzaID" :foodName="item.pizzaName" :foodID="item.pizzaID" type="pizza"/>
  </div>
</template>

<script>
import FoodButton from '../components/FoodButton.vue'
export default {

  components: {
    FoodButton
  },
  computed: {
    pizzas(){
      return this.$store.state.pizzas
    }
  }
}
</script>
<style>
.specialtiesBody{
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  align-content: center;
  min-height: 100vh;
}
</style>