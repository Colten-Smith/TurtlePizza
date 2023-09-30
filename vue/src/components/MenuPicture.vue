<template>
  <div class="realMenu">
    <div class="menu-item" @click="openFullSize('/img/2.png')">
      <img src="/img/2.png" title="Click to see full-size" />
    </div>
    <div class="menu-item" @click="openFullSize('/img/3.png')">
      <img src="/img/3.png" title="Click to see full-size" />
    </div>
    <div class="menu-item" @click="openFullSize('/img/4.png')">
      <img src="/img/4.png" title="Click to see full-size" />
    </div>
  </div>
</template>

<script>
export default {
  name: "menu-picture",
  methods: {
    openFullSize(imageUrl) {
      window.open(imageUrl, "_blank");
    }
  }
};
</script>


<style>
.realMenu {
  display: flex;
  justify-content: space-around;
  align-items: center;
  width: 100vw;
  overflow-x: auto;
  padding: 10px;
  box-shadow: 0px 15px 30px 20px rgba(0, 0, 0, 0.4);
  
}

.menu-item {
  flex: 0 0 auto;
  width: calc(33.33% - 10px);
  max-width: 300px;
  overflow: hidden;
  transition: transform 0.3s, filter 0.3s, width 0.3s;
}

.menu-image {
  width: 100%;
  height: auto;
  transition: transform 0.3s, filter 0.3s;
}

.menu-item:hover {
  width: calc(66.66% - 10px);
  transform: scale(1.5);
}

.menu-item:hover .menu-image {
  filter: brightness(0.7);
  transform: scale(1.5);
}
</style>