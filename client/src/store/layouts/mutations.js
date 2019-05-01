
// Mutation set layoutData in state for initial run.
export const saveLayout = (state, initialLayoutData) => {
  state.gridLayout = initialLayoutData
}

// Mutation new basic grid item in gridLayout.
export const setNewGridItem = (state, inputFieldLayout) => {
  console.log(inputFieldLayout)
  state.gridLayout.push(inputFieldLayout)
}

// List of templates from backend.
export const getListOfGridItems = (state, payload) => {
  console.log(payload)
  let tableData = [ ]
  for (let key in payload) {
    const template = { }
    // console.log(payload[key])
    template.id = payload[key].id
    template.name = payload[key].name
    template.completedDate = payload[key].completedForms[0].completedDate
    template.headline = payload[key].formFields[0].headline
    tableData.push(template)
  }
  console.log(tableData)
  state.tableData.push(tableData)
  state.listOfGridlayouts.push(payload)
}

// Mutation to remove item from gridLayout.
export const removeItem = (state, payload) => {
  // console.log('MUTATIONS ' + payload.key)

  // console.log(state.gridLayout)

  // state.gridLayout = state.gridLayout.slice(0, id).concat(state.gridLayout.slice(id + 1, state.gridLayout.length))

  // state.gridLayout.splice(state.gridLayout.indexOf(id))
  // let deleteLayout = state.gridLayout.map(item => item.id).indexOf(id) // find index of your object
  // let deleteLayout = state.gridLayout.filter(item => item.id).indexOf(id)
  // let deleteLayout = state.gridLayout.findIndex(t => t.id === id)

  /* let deleteLayout = state.gridLayout.filter((item) => item.id === id)
  console.log(deleteLayout)
  state.gridLayout.splice(state.gridLayout.indexOf(deleteLayout[0]), 1) */

  // Be sure static is false when deleting.
  for (let x in state.gridLayout) {
    if (state.gridLayout[x].i === payload.key) {
      state.gridLayout.splice(state.gridLayout[x], 1)
    }
  }
  // state.gridLayout.splice(state.gridLayout[payload.item], 1)

  /* if (payload.key > -1) {
    state.gridLayout.splice(payload.key, 1)
  } */

  // state.gridLayout.splice(state.gridLayout.indexOf(payload.key), 1)

  // state.gridLayout.splice(state.gridLayout.item.id === id, 1)

  /* if (deleteLayout.length === 1) {
    state.gridLayout.splice(state.gridLayout.indexOf(deleteLayout[0]), 1)
  } */

  // console.log(state.gridLayout)
}

// Save name of input field
export const saveNameOfInputField = (state, payload) => {
  state.gridLayout[payload.itemIndex] = payload.item
}

// Save lock on component in state
export const saveLockOnComponent = (state, payload) => {
  for (let x in state.gridLayout) {
    if (state.gridLayout[x].i === payload.key) {
      state.gridLayout[x].static = payload.val
    }
  }
}
