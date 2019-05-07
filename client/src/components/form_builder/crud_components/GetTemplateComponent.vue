<template>
  <q-page>

    <H2>Get Saved Template</H2>

    <q-btn label="Refresh" color="primary" @click="this.onRefresh" class="q-mb-md" ></q-btn>

    <q-table
      :loading="loading"
      title="All Templates"
      :data="data"
      :columns="columns"
      row-key="id"
      selection="single"
      :selected.sync="selected"
    >

    <template slot="top-selection" >
        <q-btn color="negative" flat round icon="delete" @click="deleteRow" />
    </template>

    <q-tr slot="body-cell-action" slot-scope="props" :props="props">

        <q-td key="id" :props="props">{{ props.row.id }}</q-td>

        <q-td key="name" :props="props">
          {{ props.row.name }}
          <q-popup-edit v-model="props.row.name" title="Update Name" buttons>
            <q-input type="string" v-model="props.row.name" />
          </q-popup-edit>
        </q-td>

        <q-td key="headline" :props="props">{{ props.row.headline }}</q-td>
        <q-td key="completedDate" :props="props">{{ props.row.completedDate }}</q-td>
      </q-tr>
    </q-table>

    <div v-if="selected">
      Selected: {{ JSON.stringify(selected) }} <!-- [0].name -->
      <br>
      one:
    </div>
    <p>asd: {{data}}</p>

  </q-page>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {

  data () {
    return {
      loading: true,
      selected: [ ],
      data: this.getTableData,
      columns: [
        {
          // name: 'desc',
          required: true,
          // label: 'Template',
          // align: 'left',
          // field: row => row.name,
          sortable: true
        },
        { name: 'id', align: 'left', label: 'Id', field: 'id', sortable: true },
        { name: 'name', label: 'Name', field: 'name', sortable: true },
        { name: 'headline', label: 'Headline', field: 'headline', sortable: true },
        { name: 'completedDate', label: 'Completed Date', field: 'completedDate', sortable: true }

      ]
    }
  },
  created () {
    this.onRefresh()
  },
  methods: {
    ...mapActions([
      'fetchFormsFromDb'
    ]),
    onRefresh () {
      const fetchTableData = this.fetchFormsFromDb()

      Promise.all([fetchTableData])
        .then(() => {
          this.data = this.$store.getters.getTableData
          this.loading = false
        })
    },
    deleteRow () {
      console.log('DeleteRow')
    }
  },
  computed: {
    ...mapGetters([
      'getTableData'
    ])
  }
}

// https://quasar-framework.org/components/datatable.html
// https://quasar-framework.org/components/popup-edit.html
// https://github.com/quasarframework/quasar-play/blob/master/src/pages/showcase/grouping/table/table-features.vue
// https://quasar-framework.org/quasar-play/android/index.html#/showcase/grouping/table/table-features
// https://quasar-framework.org/quasar-play/android/index.html#/showcase/grouping/table/table-features
// https://v0-14.quasar-framework.org/quasar-play/android/index.html#/showcase/grouping/data-table

</script>
