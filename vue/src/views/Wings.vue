<template>
  <div class="wingsBody" >
    <food-button v-for="item in wings" :price="item.price" :key="item.sideID" :foodName="item.sideName" :foodID="item.sideID" type="side"/>
  </div>
</template>

<script>
import FoodButton from '../components/FoodButton.vue'
export default {

  components: {
    FoodButton
  },
  computed: {
    wings(){
      return this.$store.state.wings
    }
  }
}
</script>
<style>
.wingsBody{
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  align-content: center;
  min-height: 100vh;
}
</style>