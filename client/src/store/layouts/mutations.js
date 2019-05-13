
// Mutation set layoutData in state for initial run.
export const saveLayout = (state, initialLayoutData) => {
  state.gridLayout = initialLayoutData
}

// Mutation new basic grid item in gridLayout.
export const setNewGridItem = (state, inputFieldLayout) => {
  console.log(inputFieldLayout)
  state.gridLayout.push(inputFieldLayout)
  console.log(state.gridLayout)
}

// List of templates from backend.
export const getListOfGridItems = (state, payload) => {
  console.log('paykload')
  console.log(payload)
  let tableData = [ ]
  for (let key in payload) {
    const template = { }
    console.log('getListOfGridItems')
    console.log(payload[key])
    template.id = payload[key].id
    template.name = payload[key].name
    template.completedDate = payload[key].completedForms[0].completedDate
    template.headline = payload[key].formFields[0].headline
    template.indexFromFetch = key
    console.log('MUTATIONS: ')
    console.log(template)
    tableData.push(template)
  }
  console.log('TABLEDATA' + tableData)
  state.tableData = tableData
  state.fetchedGridlayouts = payload
}

// Update row in state after put in action
// The method is not needed because the store is updated when the component rerender
export const storeUpdatRow = (state, payload) => {
  const tableData = state.tableData.filter((row) => row.id === payload.id)
  if (tableData.length === 1) {
    tableData[0].name = payload.name
    tableData[0].headline = payload.headline
  }
}

// Delete row in state after delete action
export const storeDeleteRow = (state, id) => {
  let tableData = state.tableData.filter((row) => row.id === id)
  if (tableData.length === 1) {
    state.tableData.splice(state.tableData.indexOf(tableData[0]), 1)
  }
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
