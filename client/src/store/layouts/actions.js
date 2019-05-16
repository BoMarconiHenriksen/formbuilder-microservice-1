import axios from 'axios'
import state from '../layouts/state'
const baseUrl = 'https://localhost:5001/api'

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

  // Create an array of obejcts
  // let listOfWidget = [ ]
  // listOfWidget.push(inputFieldLayout)

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

// Fetch the forms from the database
export async function fetchFormsFromDb ({ commit }) {
  // commit('setLoading', true)
  try {
    const response = await axios.get(`${baseUrl}/Forms/`)
    commit('getListOfGridItems', response.data)
  } catch (err) {
    console.log(err)
  }
  //  commit('setLoading', false)
}

// Update table row in database
export async function updateRow ({ commit }, row) {
  var updateTableData = getInitialTableFetch()

  updateTableData[0].name = row.name
  updateTableData[0].formFields[0].headline = row.headline
  updateTableData[0].completedForms[0].completedDate = row.completedDate

  try {
    await axios.put(`${baseUrl}/Forms/${row.id}`, updateTableData[0])
    commit('storeUpdatRow', row)
  } catch (err) {
    console.log(err)
  }
}

// Post new item
export async function postTemplate ({ commit }, template) {
  try {
    await axios.post(`${baseUrl}/Forms/`, { id: template.id, name: template.name, formFields: template.formFields, completedForms: template.completedForms })
    commit('updateTableAfterPost', template)
  } catch (err) {
    console.log(err)
  }
}

// Delete table row in database
export async function deleteRow ({ commit }, id) {
  try {
    axios.delete(`${baseUrl}/Forms/${id}`)
    commit('storeDeleteRow', id)
  } catch (err) {
    console.log(err)
  }
}

// Helper methods for generating and checking random numbers for the id.
function generateRandomNumber () {
  let generatedNumber = Math.floor(Math.random() * Math.floor(10000000))
  return generatedNumber
}

// Helper method that get the state of the initial fetch
function getInitialTableFetch () {
  let fetchedGridlayouts = state.fetchedGridlayouts
  return fetchedGridlayouts
}
