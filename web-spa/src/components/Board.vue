<template>
  <v-container fluid @click="openEditNote">
    <v-dialog v-model="dialog" persistent max-width="600px">
      <v-card>
        <v-card-title>
          <span class="headline">{{dialogTitle}}</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12">
                <v-text-field label="Title*" required></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-textarea name="input-7-1" filled label="Content*" auto-grow></v-textarea>
              </v-col>
            </v-row>
          </v-container>
          <small>*indicates required field</small>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="dialog = false">Close</v-btn>
          <v-btn color="blue darken-1" text @click="dialog = false">Save</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-row dense>
      <v-col v-for="target in targets" :key="target.id" :cols="target.flex">
        <v-hover v-slot:default="{ hover }" open-delay="200">
          <v-card :elevation="hover ? 16 : 2">
            <v-card-title v-text="target.title"></v-card-title>
            <draggable class="dragArea list-group" :list="target.tasks" group="spec">
              <div style="overflow-y: auto; max-height: 700px;">
                <v-container>
                  <v-row dense>
                    <draggable
                      class="dragArea list-group"
                      :list="target.tasks"
                      group="spec"
                      @change="handleChangCard($event, )"
                    >
                      <v-col cols="12" v-for="task in target.tasks" :key="task.id">
                        <div class="note-item">
                          <v-card :color="target.color" dark class="detail-note" :id="task.id">
                            <v-card-title class="headline note-item">{{task.taskTitle}}</v-card-title>
                            <v-card-subtitle class="note-item" :id="task.id">{{task.content}}</v-card-subtitle>
                          </v-card>
                        </div>
                      </v-col>
                    </draggable>
                  </v-row>
                </v-container>
              </div>
            </draggable>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn icon class="add-note">
                <v-icon class="add-note">mdi-plus</v-icon>
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-hover>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import draggable from "vuedraggable";
export default {
  name: "Board",
  components: {
    draggable,
  },
  data: () => ({
    targets: [
      {
        id: 1,
        title: "chưa làm",
        flex: 4,
        color: "#22472C",
        tasks: [
          {
            id: 6,
            taskTitle: "test 1",
            content:
              "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut eu semper ante. Aliquam magna diam, rhoncus non egestas ac, scelerisque a nibh. Maecenas in ipsum magna. Nunc condimentum sodales eros nec sagittis. Nulla fermentum, enim sit amet hendrerit malesuada, lorem sapien vehicula erat, non congue felis massa quis libero. Nulla euismod quam ac ex facilisis posuere. Donec ac urna viverra, dignissim nisi eget, bibendum nulla.",
          },
          { id: 7, taskTitle: "test 2", content: "test 2" },
        ],
      },
      {
        id: 2,
        title: "đang làm",
        flex: 4,
        color: "#385F73",
        tasks: [
          {
            id: 8,
            taskTitle: "visual studio",
            content:
              "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam vestibulum, sapien eu lobortis malesuada, diam leo finibus diam, in elementum lacus ipsum in libero. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Maecenas eget mauris dui. Integer non tortor nec dolor semper dictum. Aliquam lacinia tempus iaculis. Aenean rutrum congue tempor. Quisque commodo semper ante, eget eleifend enim malesuada et. Aenean tincidunt mollis ante, at ultrices eros interdum ut. Phasellus dui sapien, pellentesque vel mi at, feugiat auctor ipsum.",
          },
          { id: 9, taskTitle: "jetbrains", content: "jetbrains" },
          { id: 10, taskTitle: "eclips", content: "eclips" },
        ],
      },
      {
        id: 3,
        title: "sẽ làm",
        flex: 4,
        color: "#40060B",
        tasks: [],
      },
    ],
    dialog: false,
    dialogTitle: "",
    noteId: "",
  }),
  methods: {
    openEditNote(e) {
      if (e.target.matches(".note-item")) {
        this.noteId = e.target.id;
        this.dialog = true;
        this.dialogTitle = "Edit Note";
      }
      if (e.target.matches(".add-note")) {
        this.dialog = true;
        this.dialogTitle = "Add Note";
      }
    },
    handleChangCard(e) {
      let id = 0;
      if (Object.prototype.hasOwnProperty.call(e, "moved")) {
        id = e.moved.element.id;
      } else if (Object.prototype.hasOwnProperty.call(e, "removed")) {
        id = e.removed.element.id;
      } else if (Object.prototype.hasOwnProperty.call(e, "added")) {
        id = e.added.element.id;
      }
      console.log(id);
    },
  },
};
</script>
<style scoped>
.detail-note {
  cursor: all-scroll;
  height: 100% !important;
}
</style>
