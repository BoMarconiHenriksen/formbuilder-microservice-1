// import axios from 'axios'

// const baseUrl = 'https://localhost:5001'

import initialLayoutData from '../../assets/savedLayouts/demo.json'

// Array for generated ids.
var usedIds = []

// Sets the initial gridlayout with an input widget.
export const getInitialLayout = ({ commit }) => {
  console.log('I action.js ' + initialLayoutData)

  commit('saveLayout', initialLayoutData)
}

// Action to add an input field item to the state through a mutation.
export const addInputFieldToGrid = ({ commit, state }) => {
  let inputFieldLayout = {
    'x': 0, // Horizontal position of the item (in which column it should be placed).
    'y': 0, // Vertical position of the item (in which row it should be placed).
    'w': 2, // Width of the item.
    'h': 2, // Height of the item.
    'i': 'componentIndex', // Id of the item.
    'component': 'appInputFieldComponent',
    'isComponent': true,
    'content': '',
    'static': false
  }

  // Change this to a counter!
  var randomNumber = generateRandomNumber()
  let running = true
  var componentIndex = null

  while (running) {
    if (usedIds.includes(randomNumber) === true) {
      let newRandomNumber = generateRandomNumber()
      randomNumber = newRandomNumber
    } else {
      usedIds.push(randomNumber)
      componentIndex = randomNumber
      running = false
    }
  }

  inputFieldLayout.i = componentIndex

  commit('setNewGridItem', inputFieldLayout)
}

// Remove item from the state through mutation.
export const removeItem = ({ commit }, payload) => {
  commit('removeItem', payload)
}

// Save header and text from input Field.
export const saveInputField = ({ commit }, payload) => {
  commit('saveNameOfInputField', payload)
}

// Update lock on component.
export const updateLockOnComponent = ({ commit }, payload) => {
  commit('saveLockOnComponent', payload)
}

// Helper methods for generating and checking random numbers for the id.
function generateRandomNumber () {
  let generatedNumber = Math.floor(Math.random() * Math.floor(10000000))
  return generatedNumber
}
