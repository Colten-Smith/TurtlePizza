<template>
  <div class="sidesBody" >
    <food-button v-for="item in sides" :price="item.price" :key="item.sideID" :foodName="item.sideName" :foodID="item.sideID" type="side"/>
  </div>
</template>

<script>
import FoodButton from '../components/FoodButton.vue'
export default {

  components: {
    FoodButton
  },
  computed: {
    sides(){
      return this.$store.state.sides
    }
  }
}
</script>
<style>
.sidesBody{
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  align-content: center;
  min-height: 100vh;
}
</style>