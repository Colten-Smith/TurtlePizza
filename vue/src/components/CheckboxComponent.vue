<template>
  <div class="checkbox-container">
    <label>
      <input type="checkbox" v-model="isChecked" @change="handleChange" />
      {{ label }}
    </label>
  </div>
</template>

<script>
export default {
  name: "CheckboxComponent",
  props: {
    label: String,
    value: Boolean
  },
  data() {
    return {
      isChecked: this.value
    };
  },
  methods: {
    handleChange() {
      this.$emit("input", this.isChecked);
    }
  }
};
</script>

<style scoped>
.checkbox-container {
  margin: 10px;
}
</style>