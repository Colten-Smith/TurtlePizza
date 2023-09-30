<template>
  <div class = "contact-picture">
      <img src ="img/1.png">
  </div>
</template>

<script>
export default {
name: "contact-picture",
}
</script>

<style>
.contact-picture{
    display: flex;
  width: max-content;
  flex-direction: column;
  align-items: center;
  margin: 10px 1px;
  height: min-content;
  max-height: 20%;
  max-width: 75%;
  border-radius: 10px;
  box-shadow: 0px 15px 30px 20px rgba(0, 0, 0, 0.4);
}
</style>