import { readFileSync } from "node:fs";
import { defineConfig } from "vitest/config";

export default defineConfig({
  plugins: [
    {
      name: "html-as-text",
      load(id) {
        if (!id.endsWith(".html")) {
          return;
        }

        return `export default ${JSON.stringify(readFileSync(id, "utf8"))};`;
      },
    },
  ],
  test: {
    globals: true,
    include: ["test/**/*.test.ts"],
  },
});
