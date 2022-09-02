export function registerMoveEvents(id, component) {
    const target = document.getElementById(id);
    document.querySelector('body').addEventListener('contextmenu', event => event.preventDefault());
    document.querySelector('body').addEventListener('touchmove', (moveEvent) => {
        if (moveEvent.target !== target) {
            component.invokeMethodAsync('Deactivate', id);
        } else {
            const currentElement = document.elementFromPoint(moveEvent.touches[0].clientX, moveEvent.touches[0].clientY)
            if (currentElement !== target) {
                component.invokeMethodAsync('Deactivate', id);
            }
        }
    })
}