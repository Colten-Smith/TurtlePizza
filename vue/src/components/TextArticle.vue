<template>
  <div class="articleBody" :style="{ flexDirection: reverse ? 'row-reverse' : 'row'}">
    <div class="articleText" :style="{ fontSize: textSize }">
      <slot></slot> 
    </div>
    <div class="articleImage" :style="{width: imageMaxWidth}">
      <img :src="'/img/' + articleImage" :style="{ width: '100%', height: '100%', borderRadius: '10px' }">
    </div>
  </div>
</template>

<script>
export default {
  name: "text-article",
  props: ['articleImage', 'reverse', 'articleTitle', 'textSize', 'imageMaxWidth'],
};
</script>

<style scoped>
.articleBody {
  display: flex;
  justify-content: space-around;
  align-items: center;
  margin: 10px 1px;
  height: min-content;
  max-height: 20%;
  max-width: 80%;
  border-radius: 10px;
  box-shadow: 0px 15px 30px 20px rgba(0, 0, 0, 0.4); 
  background-color: white;
  background-image: url('/public/img/headTransparent.png');
  background-repeat: repeat;
}

.articleImage {
  flex: 1;
  display: flex;
  align-items: flex-end;
}

.articleImage img {
  max-width: 100%;
  max-height: 100%;
  border-radius: 10px;
}

.articleText {
  flex: 1;
  padding: 10px;
  font-size: 19px;
}
</style>