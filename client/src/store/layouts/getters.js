// Get the state of grid layout.
export const getLayoutData = (state) => {
  return state.gridLayout
}

// Get the state of the grid layout list.
export const getTableData = (state) => {
  console.log('i getters: ' + state.tableData)
  return state.tableData
}
