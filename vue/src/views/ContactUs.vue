<template>
  <div class ="Contact-Page">
    <contact-picture/>
  </div>
</template>

<script>
import ContactPicture from '../components/ContactPicture.vue';
export default {
  components: { ContactPicture },
  name: 'Contact'
};
</script>

<style>
.Contact-Page{
  display: flex;
  justify-content: center;
}
</style>