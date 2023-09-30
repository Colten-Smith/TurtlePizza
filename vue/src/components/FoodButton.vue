<template>
  <div class="foodButton">
    <div class="top">
      <div class="textBox">
        <h1 class="pizzaName">{{ foodName }}</h1>
      </div>
      <h2 class="price" v-if="type != 'pizza'">{{ twoDecimal(price) }}</h2>
      <div class="sizesBox" v-if="type == 'pizza'">
        <div class="sizeButton" v-for="size in sizes" :key="size.sizeID">
          <input
            :id="size.sizeID"
            type="radio"
            :value="size"
            v-model="outputSize"
          />
          {{ size.sizeName }}
          <h2 class="price">{{ twoDecimal(size.price) }}</h2>
        </div>
      </div>
    </div>
    <div class="orderSpecialtyButton" v-on:click="clickOrderButton">
      <h1 class="orderButtonText">Add To Order</h1>
    </div>
  </div>
</template>

<script>
export default {
  name: "food-button",
  data() {
    return {
      outputSize: this.$store.state.sizes[1],
    };
  },
  props: ["foodName", "foodID", "type", "price"],
  components: {},
  computed: {
    sizes() {
      return this.$store.state.sizes;
    },
    outputPizza() {
      return { pizza: this.foodID, size: this.outputSize.sizeID };
    },
  },
  methods: {
    clickOrderButton() {
      if (this.type == "pizza") {
        this.$store.commit("ADDPIZZATOORDER", {
          newPizza: {
            itemKey: 0,
            pizza: this.foodID,
            name: this.foodName,
            price: this.price + this.outputSize.price,
          },
          outputPizza: this.outputPizza,
        });
      } else if (this.type == "side") {
        let side = {
          itemKey: 0,
          name: this.foodName,
          price: this.price,
          id: this.foodID,
        };
        this.$store.commit("ADDSIDETOORDER", side);
      } else if (this.type == "drink") {
        let drink = {
          itemKey: 0,
          name: this.foodName,
          price: this.price,
          id: this.foodID,
        };
        this.$store.commit("ADDDRINKTOORDER", drink, this.foodID);
      }
      this.$router.push("/order");
    },
    twoDecimal(num) {
      return num.toFixed(2);
    },
  },
};
</script>

<style>
.foodButton {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
  width: 17vw;
  height: 17vw;
  background: white;
  border: 2px solid black;
  margin: 1vh 5vw 1vh 5vw;
}
.orderSpecialtyButton {
  background-color: crimson;
  color: whitesmoke;
  border: 2px solid whitesmoke;
  text-align: center;
  width: 75%;
}
.orderSpecialtyButton:hover {
  background-color: darkred;
  color: whitesmoke;
}
.textBox {
  display: flex;
  justify-content: center;
  height: max-content;
  text-align: center;
}
.pizzaName {
  font-size: xx-large;
  font-family: "TurtlesFont", sans-serif;
}
.orderButtonText {
  font-size: larger;
  font-family: "TurtlesFont", sans-serif;
}
.sizesBox {
  display: flex;
}
.price {
  font-size: large;
  font-family: "LettererPro";
}
.price:before {
  content: "$";
}
.top {
  text-align: center;
}
</style>