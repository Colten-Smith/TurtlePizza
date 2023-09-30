<template>
  <div class="drinksBody" >
    <food-button v-for="item in drinks" :price="item.price" :key="item.drinkID" :foodName="item.drinkName" :foodID="item.drinkID" type="drink"/>
  </div>
</template>

<script>
import FoodButton from '../components/FoodButton.vue'
export default {

  components: {
    FoodButton
  },
  computed: {
    drinks(){
      return this.$store.state.drinks
    }
  }
}
</script>
<style>
.drinksBody{
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  align-content: center;
  min-height: 100vh;
}
</style>