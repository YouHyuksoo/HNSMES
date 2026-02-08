/**
 * HNSMES UI Documentation - Custom JavaScript
 */

// Wait for DOM to be fully loaded
document.addEventListener('DOMContentLoaded', function() {
  
  // Initialize all custom functionality
  initCodeCopyButtons();
  initTableSort();
  initSearchEnhancements();
  initDiagramZoom();
  initScrollSpy();
  
});

/**
 * Enhance code copy buttons with visual feedback
 */
function initCodeCopyButtons() {
  const clipboardButtons = document.querySelectorAll('.md-clipboard');
  
  clipboardButtons.forEach(button => {
    button.addEventListener('click', function(e) {
      const originalTitle = this.getAttribute('title');
      
      // Show success feedback
      this.setAttribute('title', '복사 완료!');
      this.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><path d="M9 16.17L4.83 12l-1.42 1.41L9 19 21 7l-1.41-1.41z"/></svg>';
      
      setTimeout(() => {
        this.setAttribute('title', originalTitle);
        this.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><path d="M16 1H4c-1.1 0-2 .9-2 2v14h2V3h12V1zm3 4H8c-1.1 0-2 .9-2 2v14c0 1.1.9 2 2 2h11c1.1 0 2-.9 2-2V7c0-1.1-.9-2-2-2zm0 16H8V7h11v14z"/></svg>';
      }, 2000);
    });
  });
}

/**
 * Add sorting capability to tables
 */
function initTableSort() {
  const tables = document.querySelectorAll('.md-typeset table:not([class])');
  
  tables.forEach(table => {
    const headers = table.querySelectorAll('th');
    
    headers.forEach((header, index) => {
      header.style.cursor = 'pointer';
      header.addEventListener('click', () => sortTable(table, index));
      
      // Add sort indicator
      const indicator = document.createElement('span');
      indicator.className = 'sort-indicator';
      indicator.innerHTML = ' ↕';
      indicator.style.opacity = '0.3';
      indicator.style.fontSize = '0.8em';
      header.appendChild(indicator);
    });
  });
}

/**
 * Sort table by column
 */
function sortTable(table, columnIndex) {
  const tbody = table.querySelector('tbody');
  const rows = Array.from(tbody.querySelectorAll('tr'));
  const header = table.querySelectorAll('th')[columnIndex];
  
  // Determine sort direction
  const isAscending = !header.classList.contains('sort-asc');
  
  // Reset all headers
  table.querySelectorAll('th').forEach(th => {
    th.classList.remove('sort-asc', 'sort-desc');
    const indicator = th.querySelector('.sort-indicator');
    if (indicator) indicator.innerHTML = ' ↕';
  });
  
  // Set current header
  header.classList.add(isAscending ? 'sort-asc' : 'sort-desc');
  const indicator = header.querySelector('.sort-indicator');
  if (indicator) indicator.innerHTML = isAscending ? ' ↑' : ' ↓';
  
  // Sort rows
  rows.sort((a, b) => {
    const aText = a.cells[columnIndex].textContent.trim();
    const bText = b.cells[columnIndex].textContent.trim();
    
    // Try numeric comparison
    const aNum = parseFloat(aText);
    const bNum = parseFloat(bText);
    
    if (!isNaN(aNum) && !isNaN(bNum)) {
      return isAscending ? aNum - bNum : bNum - aNum;
    }
    
    // String comparison
    return isAscending 
      ? aText.localeCompare(bText, 'ko')
      : bText.localeCompare(aText, 'ko');
  });
  
  // Reorder rows
  rows.forEach(row => tbody.appendChild(row));
}

/**
 * Enhance search functionality
 */
function initSearchEnhancements() {
  // Add keyboard shortcut for search
  document.addEventListener('keydown', function(e) {
    // Ctrl/Cmd + K to focus search
    if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
      e.preventDefault();
      const searchInput = document.querySelector('.md-search__input');
      if (searchInput) {
        searchInput.focus();
      }
    }
  });
}

/**
 * Add zoom functionality to diagrams
 */
function initDiagramZoom() {
  const diagrams = document.querySelectorAll('.mermaid');
  
  diagrams.forEach(diagram => {
    diagram.style.cursor = 'zoom-in';
    
    let zoomed = false;
    
    diagram.addEventListener('click', function() {
      if (!zoomed) {
        this.style.transform = 'scale(1.5)';
        this.style.transformOrigin = 'center center';
        this.style.transition = 'transform 0.3s ease';
        this.style.cursor = 'zoom-out';
        zoomed = true;
      } else {
        this.style.transform = 'scale(1)';
        this.style.cursor = 'zoom-in';
        zoomed = false;
      }
    });
  });
}

/**
 * Scroll spy for navigation
 */
function initScrollSpy() {
  const headings = document.querySelectorAll('.md-typeset h2[id], .md-typeset h3[id]');
  const navLinks = document.querySelectorAll('.md-nav__link[href^="#"]');
  
  if (headings.length === 0 || navLinks.length === 0) return;
  
  let currentHeading = null;
  
  const observer = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
      if (entry.isIntersecting) {
        currentHeading = entry.target;
        updateActiveNav(currentHeading.id);
      }
    });
  }, {
    rootMargin: '-10% 0px -80% 0px',
    threshold: 0
  });
  
  headings.forEach(heading => observer.observe(heading));
  
  function updateActiveNav(id) {
    navLinks.forEach(link => {
      link.classList.remove('md-nav__link--active');
      if (link.getAttribute('href') === `#${id}`) {
        link.classList.add('md-nav__link--active');
      }
    });
  }
}

/**
 * Print-friendly enhancements
 */
window.addEventListener('beforeprint', function() {
  // Expand all details elements for printing
  document.querySelectorAll('details').forEach(detail => {
    detail.open = true;
  });
});

/**
 * Smooth scroll for anchor links
 */
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
  anchor.addEventListener('click', function(e) {
    const targetId = this.getAttribute('href');
    if (targetId === '#') return;
    
    const targetElement = document.querySelector(targetId);
    if (targetElement) {
      e.preventDefault();
      targetElement.scrollIntoView({
        behavior: 'smooth',
        block: 'start'
      });
    }
  });
});

/**
 * Table of Contents highlight on scroll
 */
function highlightTOC() {
  const toc = document.querySelector('.md-sidebar--secondary .md-nav');
  if (!toc) return;
  
  const tocLinks = toc.querySelectorAll('.md-nav__link');
  const headings = document.querySelectorAll('.md-typeset h2, .md-typeset h3');
  
  const scrollPos = window.scrollY + 100;
  
  headings.forEach((heading, index) => {
    if (heading.offsetTop <= scrollPos) {
      tocLinks.forEach(link => link.classList.remove('md-nav__link--active'));
      if (tocLinks[index]) {
        tocLinks[index].classList.add('md-nav__link--active');
      }
    }
  });
}

// Throttled scroll handler
let ticking = false;
window.addEventListener('scroll', function() {
  if (!ticking) {
    window.requestAnimationFrame(function() {
      highlightTOC();
      ticking = false;
    });
    ticking = true;
  }
});

// Export functions for global access
window.HNSMES = {
  sortTable: sortTable,
  highlightTOC: highlightTOC
};
