import { expect } from './jestGlobals'
import { deleteRow, fetchFormsFromDb } from '../../../src/store/layouts/actions'
import flushPromises from 'flush-promises'

// Create a fake context object.
const context = {
    commit: jest.fn()
}

deleteRow(context, { type: top })
// Page 126
