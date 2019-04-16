<template>
   <q-page>
      <H2>Form Builder</H2>

      <div class="q-pa-md q-gutter-sm">

      <q-btn color="white" text-color="black" label="Input Felt" @click="addInputFieldToGrid" />
      <q-btn color="white" text-color="black" label="Data" @click="getLayoutData" />

      </div>
      <!-- :layout: "getLayoutData" -->
      <grid-layout
         :layout.sync="getLayoutData"
         :col-num="12"
         :row-height="40"
         :is-draggable=true
         :is-resizable=true
         :is-mirrored="false"
         :vertical-compact="false"
         :margin="[15, 15]"
         :use-css-transforms="true">

      <grid-item v-for="(item, index) in getLayoutData" :key="item.i"
         :autoSize="true"
         :x="item.x"
         :y="item.y"
         :w="item.w"
         :h="item.h"
         :i="item.i"
         :static="item.static">

         <template>
            <!-- Show component. item og itemIndex is passed as props.-->
            <component v-if="item.isComponent"
            :is="item.component"
            :item="item"
            :itemIndex="index">
            </component>

            <app-delete-alert :item="item"/>

         </template>

         </grid-item>
      </grid-layout>

   </q-page>
</template>

<script>
import { GridLayout, GridItem } from 'vue-grid-layout'
import { mapGetters, mapActions } from 'vuex'
import InputFieldComponent from './widgets/InputFieldComponent.vue'
import DeleteAlert from './helper_components/DeleteAlert.vue'

export default {
  components: {
    appInputFieldComponent: InputFieldComponent,
    appDeleteAlert: DeleteAlert,
    GridLayout,
    GridItem
  },
  data () {
    return {

    }
  },
  methods: {
    ...mapActions([
      'addInputFieldToGrid',
      'editLabel'
    ])
  },
  computed: {
    ...mapGetters([
      'getLayoutData'
    ])
  }
}
</script>

<style>
.vue-grid-layout {
  background: #eee;
}

.vue-grid-item:not(.vue-grid-placeholder) {
  background: #ccc;
  border: 1px solid black;
}

.vue-grid-item.resizing {
  opacity: 0.9;
}

.vue-grid-item.static {
  background: #cce;
}

.vue-grid-item .text {
  font-size: 24px;
  text-align: center;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  margin: auto;
  height: 24px;
}

.vue-grid-item .minMax {
  font-size: 12px;
}

.vue-grid-item .add {
  cursor: pointer;
}
</style>
