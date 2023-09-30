<template>
  <div id="app">
    <HeaderBar />
    <router-view />
  </div>
</template>

<script>
import HeaderBar from '@/components/headerBar.vue'; 

export default {
  components: {
    HeaderBar,
  },
};
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
</style>
