<template>
  <div>
    <div class="home">
    
      <body>
        <div id="articleContainer">
          <text-article
            articleImage="mutagen ooze.jpg"
            :reverse="0"
            
            
          >
            <p>Step back in time to the radical era of the early 90s with our totally tubular exclusive Mountain Dew flavor, <span class="mo-text">Mutagen Ooze!</span> 🐢🍕 Channel your inner Teenage Mutant Ninja Turtle as you sip on this gnarly concoction that's only available at Turtle Pizza. Picture yourself skateboarding through neon-lit streets with the essence of pizza in the air, because this drink brings together the zesty zest of classic Mountain Dew with a twist of oozy adventure. Its neon green hue glows like the ooze that transformed those awesome crime-fighting turtles, and its electrifying citrus taste is totally radical. Cowabunga, dudes and dudettes, grab your slice of nostalgia and take a sip of Mutagen Ooze for a totally bodacious experience that'll transport you back to the golden age of 90s awesomeness!</p>
          </text-article>
          <text-article 
            articleImage="TheShredder.jpg"
            :reverse="1"
          >
            <p>Experience pizza perfection with our specialty <span class="shred-text">The Shredder!</span> Named after the infamous TMNT villain, this pie is a tribute to boldness and flavor innovation. Packed with the intense kick of Hot Sausage and elevated by the creamy richness of pepperjack cheese, each bite is a symphony of satisfying heat and indulgence. But there's more to this pizza than meets the eye – a daring ghost pepper drizzle that adds a fiery crescendo to every mouthful. Much like Shredder's calculated cunning, The Shredder pizza takes your taste buds on a journey of surprise and excitement. Get ready for an unparalleled pizza adventure that leaves an impression as lasting as the villain himself!</p>
          </text-article>
        </div>
      </body>

    <footer>

    </footer>

    </div>
  </div>
</template>

<script>
import TextArticle from '../components/TextArticle.vue';

export default {
  
  name: "home",
  components: {
    TextArticle,
    
    },
        
};
</script>

<style>
  #articleContainer{
    display: flex;
    flex-direction: column;
    width: 100vw;
    align-items: center;
    font-family: "LettererPro";
    
    
  }
  .mo-text {
    font-size: 24px;
    color: red; 
  }
  .shred-text {
    font-size: 24px;
    color: blueviolet;
  }
  #shred-text2{
    text-align: justify;
  }
  
</style>