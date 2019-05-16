import { expect } from './jestGlobals'
import { fetchFormsFromDb } from '../../../src/store/layouts/actions'
import { fetchListData } from '../__tests__/actionTestHelper/api'
import flushPromises from 'flush-promises'

// https://alexjover.com/blog/

// jest.mock('../__tests__/actionTestHelper/api.js')

/* describe('action', () => {
    test('fetchFormsFromDb make a request and commit the response', async () => {
        expect.assertions(1)
        // Create the data that is passed into the tests
        const items = [{ }, { }]
        // const row = 'top'
        // Returns a resolved promise with the items if fetchListData is called with the right type else
        // it will return an empty resolved promise
        fetchListData.mockImplementationOnce(calledWith => {
            return calledWith === row
            ? Promise.resolve(items)
            : Promise.resolve()
        })
        // Create a fake context object.
        const context = {
            commit: jest.fn()
        }
        // And call the action with the fake context object.
        fetchFormsFromDb(context)
        // Wait for the pending promise
        await flushPromises()
        // Check that commit was called with the right value
        expect(context.commit).toHaveBeenCalledWith('getListOfGridItems', { items })
    })
}) */
