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
export const fetchFormsFromDb = ({ commit }) =>
  new Promise((resolve, reject) => {
    axios.get(`${baseUrl}/Forms/`).then(response => {
      console.log('FETCH:')
      console.log(JSON.stringify(response.data))
      commit('getListOfGridItems', response.data)
      resolve()
    }).catch(error => {
      reject(error)
    })
  })

// Update table row in database
export const updateRow = ({ commit }, row) =>
  new Promise((resolve, reject) => {
    console.log('ROW')
    console.log(row)
    var updateTableData = getInitialTableFetch()
    console.log('BEFORE UPDATE')
    console.log(updateTableData)

    var rowToSend = updateTableData[row.indexFromFetch]
    console.log('ROWTOSEND')
    console.log(rowToSend)

    updateTableData[0].name = row.name
    updateTableData[0].formFields[0].headline = row.headline
    updateTableData[0].completedForms[0].completedDate = row.completedDate
    console.log('Efter update')
    console.log(updateTableData)

    axios.put(`${baseUrl}/Forms/${row.id}`, updateTableData[0]).then(response => {
      console.log('AFTER COMMIT')
      console.log(updateTableData)
      commit('storeUpdatRow', row)
      resolve()
    }).catch(error => {
      reject(error)
    })
  })

// Update table row in database
export const postTemplate = ({ commit }, template) =>
  new Promise((resolve, reject) => {
    console.log('BEFORE POST')
    console.log(template)
    axios.post(`${baseUrl}/Forms/`).then(response => {
      console.log('AFTER COMMIT')
      console.log(template)
      commit('updateTableAfterPost', template)
      resolve()
    }).catch(error => {
      reject(error)
    })
  })

// Delete table row in database
export const deleteRow = ({ commit }, id) =>
  new Promise((resolve, reject) => {
    axios.delete(`${baseUrl}/Forms/${id}`).then(response => {
      commit('storeDeleteRow', id)
      resolve()
    }).catch(error => {
      reject(error)
    })
  })

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
