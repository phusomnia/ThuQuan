/**
 * JS toggle
 *
 * Cách dùng:
 * <button class="js-toggle" toggle-target="#box">Click</button>
 * <div id="box">Content show/hide</div>
 */
function initJsToggle() {
   document.querySelectorAll(".js-toggle").forEach((button) => {
      const target = button.getAttribute("toggle-target");
      if (!target) {
         console.error(`Cần thêm toggle-target cho: ${button.outerHTML}`);
         return;
      }
      (button as HTMLElement).onclick = () => {
         const targetElement = document.querySelector(target);
         if (!targetElement) {
            console.error(`Không tìm thấy phần tử "${target}"`);
            return;
         }
         const isHidden = targetElement.classList.contains("hide");

         requestAnimationFrame(() => {
            targetElement.classList.toggle("hide", !isHidden);
            targetElement.classList.toggle("show", isHidden);
         });
      };
   });
}

export { initJsToggle };
