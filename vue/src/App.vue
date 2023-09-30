<template>
  <div id="app">
    <app-header id="header"></app-header> 
    <body id="pizza">
    <router-view/>
    </body>
  </div>
</template>

<script>
import AppHeader from '@/components/AppHeader.vue';
import PizzaService from '@/services/PizzaService.js'

export default {
  components: {
    AppHeader
  },
  
  created(){
    PizzaService.getpizzas(this.$store)
    PizzaService.getsides(this.$store)
    PizzaService.getwings(this.$store)
    PizzaService.getdrinks(this.$store)
    PizzaService.getsizes(this.$store)
  }
  
}
</script>
<style>
@font-face {
  font-family: "TurtlesFont";
  src: url("@/Fonts/Turtles.otf") format("opentype");
}
@font-face {
  font-family: "LettererPro";
  src: url("@/Fonts/VTC Letterer Pro Regular.ttf") format("truetype")
}
#app {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

#pizza {
  flex-grow: 1;
  background-image: url('/public/img/pizzaBackground.png');
  background-size: cover;
  background-repeat: no-repeat;
  background-attachment: scroll;
}
#header {
  position: sticky;
  top: -370px;
}
</style>
