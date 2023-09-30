<template>
  <div class="Menu-Page">
    <menu-picture/>
  </div>
</template>

<script>
import MenuPicture from '../components/MenuPicture.vue';
export default {
  name: 'Menu',
  components: {
    MenuPicture,
  }
};
</script>

<style>
.Menu-Page{
  height: 100vh;
  flex-wrap: wrap;
  display: flex;
  justify-content: center;
   
}

</style>