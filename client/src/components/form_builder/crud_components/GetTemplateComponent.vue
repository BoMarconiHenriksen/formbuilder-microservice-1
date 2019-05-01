<template>
  <q-page>

    <H2>Get Saved Template</H2>
    <q-btn color="white" text-color="black" label="Get Data" @click="fetchFormsFromDb" />

    <q-table
      title="All Templates"
      :data="data"
      :columns="columns"
      row-key="name"
      selection="single"
      :selected.sync="selected"
    />

    <div>
      Selected: {{ JSON.stringify(selected) }}
    </div>
    <p>asd: {{data}}</p>
  </q-page>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
/*   preFetch ({ store }) {
    // initialize something in store here
    Loading.show()
    new Promise((resolve, reject) => {
    axios.get(`${baseUrl}/Forms/`).then(response => {
      return store.dispatch(response.data)
      resolve()
      }).then(() => {
        Loading.hide()
      }).catch(error => {
        reject(error)
      })
    })
  }, */
  data () {
    return {
      selected: [ ],
      data: this.getTableData,
      columns: [
        {
          name: 'desc',
          required: true,
          label: 'Template',
          align: 'left',
          field: row => row.name,
          format: val => `${val}`,
          sortable: true
        },

        { name: 'id', align: 'left', label: 'Id', field: 'id', sortable: true },
        { name: 'name', label: 'Name', field: 'name', sortable: true }

      ]
    }
  },
  methods: {
    ...mapActions([
      'fetchFormsFromDb'
    ])
  },
  computed: {
    ...mapGetters([
      'getTableData'

    ])
  }
}
</script>
